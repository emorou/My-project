-> Main

=== Main ===

Halo, Celtic! #speaker: Celestina #sprite: Celestina Idle #layout: right

Hi, Celes #speaker: Celtic #sprite: Celtic #layout: left

Mau permen gak? #speaker: Celestina #sprite: Celestina Jump #layout: left

+ [Iya, mau oreo!]
    -> respond("oreo")
    
+ [Enggak, aku lagi diet]
    Kecewa berat #speaker: Celestina #sprite: Celestina Shake #layout: right
-> DONE

=== respond(candy) ===
Oke, nih {candy}nya #speaker: Celestina Idle #sprite: Celestina #layout: right
Makasih! #speaker: Celtic #sprite: Celtic #layout: left
-> END