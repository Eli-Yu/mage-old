.gba
.open "MF_J.gba","MF_J_testDemo.gba",0x8000000

.definelabel GameMode,0x3000C12
.definelabel DemoFlag,0x30014BC
.definelabel PlayMusic,0x800359C
.definelabel DemoNumber,5


; new code
.org 0x80332D4      ; unused sprite AI
LoadDemo:
    ; set game mode values
    ldr     r0,=GameMode
    mov     r1,3
    strh    r1,[r0,2]
    mov     r1,4
    strh    r1,[r0,4]
    ; set flag to load into demo
    ldr     r0,=DemoFlag
    mov     r1,1
    strb    r1,[r0]
    ; play title screen music
    mov     r0,0x4A
    mov     r1,0x10
    bl      PlayMusic
    ; return to hijacked code
    ldr     r0,=0x8088624
    mov     r15,r0
    .pool


; hijack code that initializes SubGameMode1
.org 0x80885D2
    ldr     r0,=LoadDemo
    mov     r15,r0
    .pool

; set demo number
.org 0x8071F94
    mov     r0,DemoNumber
    strb    r0,[r2]
    b       0x8071FB6

; repeat same demo
.org 0x8072024
    b       0x807206C

; disable input
.org 0x800CB40
    b       0x800CB6C


.close
