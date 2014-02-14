namespace CoinChange.Test

module PropertyTests =

    open CoinChange
    open FsCheck
    open FsUnit.Xunit

    let changeOfAmountShouldSumToIt algorithm coins cents =
        let result = algorithm coins (Ct cents)
        Coins.amount result |> should equal (Ct cents)

    let solutionFoundIsNotWorse algorithm coins selection =
        let rec sumUp cs ss (sum, count) =
            match (cs, ss) with
            | (c::cs, (NonNegativeInt n)::ss) -> sumUp cs ss (n * Coins.centValue c + sum, count+n)
            | (_,_)                           -> (Ct sum, count)
        let (cents, count) = sumUp coins selection (0,0)
        let resultCount = algorithm coins cents |> List.length
        resultCount |> should be (lessThanOrEqualTo count)