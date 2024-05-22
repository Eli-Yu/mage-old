.gba
.open "MF_U.gba","MF_U_testCredit.gba",0x8000000

.definelabel GameMode,0x3000BDE


; new code
.org 0x8033114      ; unused sprite AI
LoadCredit:
	ldr		r1,=GameMode
	mov		r0,0Bh
	strh	r0,[r1]
	mov		r0,0h
	strb	r0,[r4]
	strh	r0,[r1,2]
	strb	r0,[r5]
	bl		800074Ch
.pool


; hijack code that initializes SubGameMode1
.org 0x80876AE
    ldr     r0,=LoadCredit
    mov     r15,r0
.pool

.close
