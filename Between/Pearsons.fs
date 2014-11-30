namespace Between

module Pearsons = 

    let rec getShared a b c =
        match a, b with
        | [], _ -> c
        | _, [] -> c
        | aHead::aTail, bHead::bTail when fst aHead < fst bHead -> getShared aTail b c
        | aHead::aTail, bHead::bTail when fst aHead > fst bHead -> getShared a bTail c
        | aHead::aTail, bHead::bTail -> getShared aTail bTail ((fst aHead, (snd aHead, snd bHead))::c)
    
    let ratingA e =
        fst (snd e)
        
    let ratingB e =   
        snd (snd e)

    let calculate (a : list<int*double>) (b : list<int*double>) =
        let shared = getShared (a |> List.sortBy fst) (b |> List.sortBy fst) []
        let avgA = List.sumBy (fun e -> ratingA e) shared / double (List.length shared)
        let avgB = List.sumBy (fun e -> ratingB e) shared / double (List.length shared)

        (List.sumBy (fun e -> (ratingA e - avgA) * (ratingB e - avgB)) shared) /
        (
            (sqrt (List.sumBy (fun e -> (ratingA e - avgA)**2.0) shared)) *
            (sqrt (List.sumBy (fun e -> (ratingB e - avgB)**2.0) shared))
        )