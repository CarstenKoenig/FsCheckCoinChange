namespace CoinChange

type Cents  = 
    | Ct of int
    override c.ToString() = 
        match c with
        | Ct ct -> sprintf "%d ct" ct

type Coin =
    | Euro of int
    | Cent of int

module Coins =
    
    let inCent : Coin -> Cents = 
        function
        | Euro e -> Ct (100*e)
        | Cent c -> Ct c

    let centValue : Coin -> int =
        let value (Ct ct) = ct
        inCent >> value

    let amount : Coin list -> Cents = 
        let unwrap (Ct c) = c
        List.sumBy (inCent >> unwrap) >> Ct

type CoinChangeAlgorithm = Coin list -> Cents -> Coin list