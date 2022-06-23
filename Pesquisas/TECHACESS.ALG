algoritmo "techAcess"

//[ALUNOS]:
//Angela Akemi Hiroishi - Gabriel Miranda - Geovana da Costa Andrade
//Guilherme Henrique Moura Neves - Guilherme Henrique Santos Rodrigues

var
   loop,aut,t: logico
   i,i2,r: inteiro
   tuser,tpw: caracter
   user,pw: vetor[0..10] de caracter


procedimento init
inicio
   para i de 0 ate 10 faca
      user[i]<-"0"
      pw[i]<-"0"
   fimpara
fimprocedimento


procedimento login
inicio

   aut<-falso

   escreval()

   se (user[0]<>"0") entao
   senao
      escreval("nenhum usuario cadastrado na base")
      escreval("favor cadastrar:")
      cadastrar
   fimse

   escreval("[login]")
   escreval("informe o usuario:")
   leia(tuser)
   escreval("informe a senha:")
   leia(tpw)

   para i de 0 ate 10 faca
      se (tpw=pw[i]) e (tuser=user[i]) entao
         aut<-verdadeiro
      fimse
   fimpara

   se (aut=falso) entao
      escreval("usuario ou senha incorretos!")
      escreval("aperte <enter> para retornar")
      leia(r)
      login
   senao
      escreval("usuario autenticado: ",tuser)
      escreval("aperte <enter> para retornar")
      leia(r)
   fimse

fimprocedimento


procedimento cadastrar
inicio

   t<-falso

   escreval()

   escreval("[cadastrar]")
   escreval("informe um usuario:")
   leia(tuser)

   para i de 0 ate 10 faca
      se (tuser=user[i]) entao
         escreval("usuario ja cadastrado: ", tuser)
         interrompa
      fimse
   fimpara

   escreval("informe uma senha:")
   leia(tpw)

   i2<-0
   enquanto (t=falso) faca
      se (user[i2]="0") entao
         user[i2]<-tuser
         pw[i2]<-tpw
         t<-verdadeiro
      fimse
      se (i2+1=11) entao
         escreval("limite de usuarios atingido")
         interrompa
      fimse
      i2<-i2+1
   fimenquanto

   escreval("usuario <",tuser,"> cadastrado com sucesso!")
   escreval("aperte <enter> para retornar")
   leia(r)

fimprocedimento


inicio

   loop<-verdadeiro

   init

   escreval()

   enquanto (loop=verdadeiro) faca

      limpatela

      se (tuser="") entao
      senao
         escreval("usuario: ",tuser)
      fimse

      escreval("1 - entrar")
      escreval("2 - registrar")
      escreval("0 - sair")

      escreval("informe a opcao desejada: <0-2>")
      leia(r)

      escolha r
      caso 0
         escreval("..finalizando")
         loop<-falso
      caso 1
         login
      caso 2
         cadastrar
      outrocaso
         escreval("opcao invalida!")
         escreval("aperte <enter> para retornar")
         leia(r)
      fimescolha

   fimenquanto


fimalgoritmo