namespace Between

(* 
    COSINE SIMILARITY MEASURE
*)
module Cosine = 

    let rec getShared a b c =
        match a, b with
        | [], _ -> c
        | _, [] -> c
        | aHead::aTail, bHead::bTail -> getShared aTail bTail ((aHead, bHead)::c)
//        | aHead::aTail, bHead::bTail when fst aHead > fst bHead -> getShared a bTail c
//        | aHead::aTail, bHead::bTail -> getShared aTail bTail ((fst aHead, (snd aHead, snd bHead))::c)
    
    let ratingA e =
        fst e
        
    let ratingB e =   
        snd e

    let calculate (a : list<double>) (b : list<double>) =
        let shared = getShared a b []

        (List.sumBy (fun e -> ratingA e * ratingB e) shared) /
        (
            (sqrt (List.sumBy (fun e -> (ratingA e)**2.0) shared)) *
            (sqrt (List.sumBy (fun e -> (ratingB e)**2.0) shared))
        )
