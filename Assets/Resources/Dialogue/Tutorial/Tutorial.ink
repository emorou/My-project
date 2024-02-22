INCLUDE globals.ink 

EXTERNAL BackToIntro()
EXTERNAL StartTutorial()

-> Main

=== Main ===

Hai Celtic, kau terlihat kawatir. #speaker: ??? #right sprite: Fel Bright #left sprite: Celtic Dark

Siapa Kau!?!? #speaker: Celtic #right sprite: Fel Dark #left sprite: Celtic Bright

Kau bisa memanggilku Fel, penyihir terhebat di muka bumi! #speaker: Fel #right sprite: Fel Bright #left sprite: Celtic Dark

Kau memanggil dirimu terhebat? Memang apa yang bisa kau lakukan? #speaker: Celtic #right sprite: Fel Dark #left sprite: Celtic Bright

Sepertinya kerajaan sedang dalam masalah. #speaker: Fel #right sprite: Fel Bright #left sprite: Celtic Dark

Benar sekali seperti apa yang kau lihat, kerajaan diserang oleh banyak monster yang tiba-tiba muncul di tengah kerajaan. #speaker: Celtic #right sprite: Fel Dark #left sprite: Celtic Bright

Kau bertanya apa yang bisa ku lakukan sebelumnya? Aku bisa membantumu melawan monster-monster itu. #speaker: Fel #right sprite: Fel Bright #left sprite: Celtic Dark

Kau akan melawan mereka? #speaker: Celtic #right sprite: Fel Dark #left sprite: Celtic Bright

Tidak. #speaker: Fel #right sprite: Fel Bright #left sprite: Celtic Dark

Aku tidak mengerti apa yang kau maksud. Aku akan pergi dari sini. #speaker: Celtic #right sprite: Fel Dark #left sprite: Celtic Bright

Tunggu! #speaker: Fel #right sprite: Fel Bright #left sprite: Celtic Dark

Apa yang kau inginkan? #speaker: Celtic #right sprite: Fel Dark #left sprite: Celtic Bright

Ambil ini. #speaker: Fel #right sprite: Fel Bright #left sprite: Celtic Dark

Fel mengeluarkan sebuah pedang dan pistol. #speaker: #right sprite: Fel Dark #left sprite: Celtic Dark

Pedang? Pedang tidak efektif terhadap monster-monster itu! #speaker: Celtic #right sprite: Fel Dark #left sprite: Celtic Bright

Ini bukan pedang biasa, coba lihat baik-baik. #speaker: Fel #right sprite: Fel Bright #left sprite: Celtic Dark

Aku sudah mencoba melawan monster itu dengan pedangku! #speaker: Celtic #right sprite: Fel Dark #left sprite: Celtic Bright

Coba lagi. Aku akan membantumu. #speaker: Fel #right sprite: Fel Bright #left sprite: Celtic Dark

+ [Terima bantuannya]
    Baiklah. Aku akan coba. #speaker: Celtic #right sprite: Fel Dark #left sprite: Celtic Bright
    ~StartTutorial()
    -> DONE
    
+ [Tolak bantuannya]
    Tidak perlu. Aku akan pergi dari tempat ini!#speaker: Celtic #right sprite: Fel Dark #left sprite: Celtic Bright
    Baiklah jika itu yang kau mau. #speaker: Fel #right sprite: Fel Bright #left sprite: Celtic Dark
    ~BackToIntro()
    
-> END