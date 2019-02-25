(set-logic BV)

(define-fun shr1 ((x (BitVec 64))) (BitVec 64) (bvlshr x #x0000000000000001))
(define-fun shr4 ((x (BitVec 64))) (BitVec 64) (bvlshr x #x0000000000000004))
(define-fun shr16 ((x (BitVec 64))) (BitVec 64) (bvlshr x #x0000000000000010))
(define-fun shl1 ((x (BitVec 64))) (BitVec 64) (bvshl x #x0000000000000001))
(define-fun if0 ((x (BitVec 64)) (y (BitVec 64)) (z (BitVec 64))) (BitVec 64) (ite (= x #x0000000000000001) y z))

(synth-fun f ( (x (BitVec 64))) (BitVec 64)
(

(Start (BitVec 64) (#x0000000000000000 #x0000000000000001 x (bvnot Start)
                    (shl1 Start)
 		    (shr1 Start)
		    (shr4 Start)
		    (shr16 Start)
		    (bvand Start Start)
		    (bvor Start Start)
		    (bvxor Start Start)
		    (bvadd Start Start)
		    (if0 Start Start Start)
 ))
)
)
(constraint (= (f #xB307EAF96F325DB9) #x0000000000000000))
(constraint (= (f #x872F0843F9954631) #x0000000000000000))
(constraint (= (f #x0EBA17DFE3CC85F3) #x0000000000000000))
(constraint (= (f #xF88CA66CDDE1B36B) #x0000000000000000))
(constraint (= (f #x37BACD27E4887983) #x0000000000000000))
(constraint (= (f #xFFFFFFFFFFFFFFFF) #x0000000000000000))
(constraint (= (f #x000000000000001F) #x0000000000000001))
(constraint (= (f #x0000000000000013) #x0000000000000001))
(constraint (= (f #x0000000000000019) #x0000000000000001))
(constraint (= (f #xC9985C408022EEA4) #xCFE51F2284240619))
(constraint (= (f #xD4200A85D0C607E2) #xDAC10AD9FF4C3821))
(constraint (= (f #xE4696047468D22C8) #xEB8CAB4980C18BDE))
(constraint (= (f #x5BB483E07E535808) #x5E9227FF8245F2C8))
(constraint (= (f #x04EA8CA194F6CD58) #x0511E106A19E83C2))
(constraint (= (f #x000000000000001A) #x000000000000001A))
(constraint (= (f #x0000000000000014) #x0000000000000014))
(constraint (= (f #x0000000000000016) #x0000000000000016))
(constraint (= (f #x0000000000000012) #x0000000000000012))
(constraint (= (f #x53FA452324897369) #x0000000000000000))
(constraint (= (f #xCC66EBCDE143DC2E) #xD2CA232C504DFB0F))
(constraint (= (f #x4E5BD484BFFA8B17) #x0000000000000000))
(constraint (= (f #xE73E5B8A8622392D) #x0000000000000000))
(constraint (= (f #x692859AD96BDE14B) #x0000000000000000))
(constraint (= (f #x3E08628E342BEA6B) #x0000000000000000))
(constraint (= (f #xBE3BCDAED7C79B38) #xC42DAC1C4E85D811))
(constraint (= (f #xC95A4ECDEA0191F9) #x0000000000000000))
(constraint (= (f #xEAD49F039A9E4D51) #x0000000000000000))
(constraint (= (f #x0365EC90488DC2E6) #x03811BF4CAD230FD))
(constraint (= (f #x0000000000000017) #x0000000000000001))
(constraint (= (f #x0000000000000010) #x0000000000000010))
(constraint (= (f #x14A503482C16861B) #x0000000000000000))
(check-synth)