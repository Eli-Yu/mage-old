.gba
.open "ZM_U.gba","ZM_U_testCredit.gba",0x8000000

.definelabel GameMode,0x3000C70


; new code
.org 0x8043DF0      ; unused sprite AI
LoadCredit:
    ; set game mode values
    ldr     r0,=GameMode
    mov     r1,0x8
    strh    r1,[r0]
    mov     r1,0
    strh    r1,[r0,2]
    strh    r1,[r0,4]
    ; return to hijacked code
    ldr     r0,=0x807EFE8
    mov     r15,r0

    .pool


; hijack code that initializes SubGameMode1
.org 0x807EFD8
    ldr     r0,=LoadCredit
    mov     r15,r0
    .pool
    
.close
