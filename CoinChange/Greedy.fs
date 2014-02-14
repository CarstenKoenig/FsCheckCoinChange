module CoinChange.Greedy

    /// basic greedy algorithm - coins have to be sorted by descending value
    let algorithm (coins : Coin list) (cents : Cents) : Coin list =
        let takeCoins (Ct cents, acc) coin =
            let value = Coins.centValue coin
            let take = List.replicate (cents / value) coin
            let rest = cents % value
            (Ct rest, acc@take)
        coins |> List.fold takeCoins (cents, []) |> snd
