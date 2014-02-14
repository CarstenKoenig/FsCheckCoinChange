module CoinChange.DynamicProgramming

    /// dynamic programming algorithm - coins have to be sorted by ascending value
    let algorithm (coins : Coin list) (cents : Cents) : Coin list =
        let coinArr = List.toArray coins
        let memoize = new System.Collections.Generic.Dictionary<_,_>()
        let rec f (amount, coinIndex) cont =
            // guards: solution found or no more coins to select from
            if amount = 0 then cont <| Some (0, []) else
            if coinIndex < 0 then cont None else
            // memoize results
            if memoize.ContainsKey (amount, coinIndex) then cont memoize.[(amount,coinIndex)] else
            let result = 
                let coin = coinArr.[coinIndex]
                let coinV = Coins.centValue coin
                if coinV <= amount then
                    f (amount, coinIndex-1) (fun res1 -> f (amount-coinV, coinIndex) (fun res2 ->
                        match res1, res2 with
                        | None, None
                            -> None
                        | (Some _ as A), None
                            -> A
                        | None, Some (countB, solB)
                            -> Some (countB+1, coin::solB)
                        | (Some (countA, _) as A), Some (countB, _) when countA <= countB
                            -> A
                        | (Some _, Some (countB, solB))
                            -> Some (countB+1, coin::solB)
                    ))
                else
                   f (amount, coinIndex-1) id

            memoize.[(amount, coinIndex)] <- result
            cont result

        match f (cents.Value, coinArr.Length-1) id with
        | Some (_, sol) -> sol
        | None          -> failwith "no solution found"