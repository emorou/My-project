EXTERNAL BackToIntro()
EXTERNAL StartTutorial()

-> Main

=== Main ===

Celtic. #speaker: ??? #right sprite: Fel Bright #left sprite: Celtic Dark

Iya... Kamu siapa? #speaker: Celtic #right sprite: Fel Dark #left sprite: Celtic Bright

Fel. #speaker: Fel #right sprite: Fel Bright #left sprite: Celtic Dark

Oke... Kenapa Anda santai aja di situ? #speaker: Celtic #right sprite: Fel Dark #left sprite: Celtic Bright

Nongkrong. #speaker: Fel #right sprite: Fel Bright #left sprite: Celtic Dark

Kamu gak lihat ada banyak monster di kerajaan?! #speaker: Celtic #right sprite: Fel Dark #left sprite: Celtic Bright

Lihat. #speaker: Fel #right sprite: Fel Bright #left sprite: Celtic Dark

Terus kenapa cuma diam aja di situ? Segera kabur! #speaker: Celtic #right sprite: Fel Dark #left sprite: Celtic Bright

Tidak perlu. #speaker: Fel #right sprite: Fel Bright #left sprite: Celtic Dark

Saya tidak mengerti apa yang Anda bicarakan. Saya akan segera pergi dari sini. #speaker: Celtic #right sprite: Fel Dark #left sprite: Celtic Bright

Tunggu. #speaker: Fel #right sprite: Fel Bright #left sprite: Celtic Dark

Apa yang Anda inginkan? #speaker: Celtic #right sprite: Fel Dark #left sprite: Celtic Bright

Ambil. #speaker: Fel #right sprite: Fel Bright #left sprite: Celtic Dark

Pedang? Pedang tidak efektif terhadap monster tersebut! #speaker: Celtic #right sprite: Fel Dark #left sprite: Celtic Bright

Salah. #speaker: Fel #right sprite: Fel Bright #left sprite: Celtic Dark

Saya sudah mencoba melawan monster itu dengan pedang saya. Pedangnya tidak efektif. #speaker: Celtic #right sprite: Fel Dark #left sprite: Celtic Bright

Coba lagi. Saya bantu. #speaker: Fel #right sprite: Fel Bright #left sprite: Celtic Dark

+ [Terima bantuannya]
    Baiklah. Saya akan mencoba lagi. #speaker: Celtic #right sprite: Fel Dark #left sprite: Celtic Bright
    ~StartTutorial()
    -> DONE
    
+ [Tolak bantuannya]
    Tidak perlu. Saya akan kabur dari tempat ini!#speaker: Celtic #right sprite: Fel Dark #left sprite: Celtic Bright
    Mengecewakan. #speaker: Fel #right sprite: Fel Bright #left sprite: Celtic Dark
    end
    ~BackToIntro()
    
-> END
