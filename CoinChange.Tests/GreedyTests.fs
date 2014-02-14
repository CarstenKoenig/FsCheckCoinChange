namespace CoinChange.Test

module ``Property tests for the greedy algorithm and default Euro-Coins`` =

    open FsCheck
    open FsCheck.Xunit

    open CoinChange

    let algorithm = Algorithms.Greedy
    let coins = [Euro 2; Euro 1; Cent 50; Cent 20; Cent 10; Cent 5; Cent 2; Cent 1]

    [<Property>]
    let ``the change for a amount A should sum to A`` (PositiveInt cents) =
        PropertyTests.changeOfAmountShouldSumToIt algorithm coins cents

    [<Property>]
    let ``given a selection of coins the found solution must not have more items then in the selection `` (selection : NonNegativeInt list) =
        PropertyTests.solutionFoundIsNotWorse algorithm coins selection

module ``Property tests for the greedy algorithm and default nasty-coins`` =

    open FsCheck
    open FsCheck.Xunit

    open CoinChange

    let algorithm  = Algorithms.Greedy
    let nastyCoins = [Cent 20; Cent 15; Cent 1]

    [<Property>]
    let ``the change for a amount A should sum to A`` (PositiveInt cents) =
        PropertyTests.changeOfAmountShouldSumToIt algorithm nastyCoins cents

    /// remark: this one should indeed fail!
    [<Property>]
    [<Xunit.Trait("expect", "failure")>]
    let ``given a selection of coins the found solution must not have more items then in the selection `` (selection : NonNegativeInt list) =
        PropertyTests.solutionFoundIsNotWorse algorithm nastyCoins selection
