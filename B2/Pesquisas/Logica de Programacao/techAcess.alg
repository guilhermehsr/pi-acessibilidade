algoritmo "techAcess"
//ALUNOS:
//Gabriel Miranda - Geovana da Costa Andrade
//Guilherme Henrique Santos Rodrigues

tipo
   User = registro
      userN: caracter
      passW: caracter
   fimregistro

var
   usr,tuser,tpw: caracter
   aut: logico
   r,j,k: inteiro
   userV: vetor[0..100] de User

procedimento login(u: caracter; p: caracter)
inicio
   escreval()
   se (checkU(u) = verdadeiro) entao
      se (userV.passW[j] = p) entao
         usr<-u
         aut<-verdadeiro
         escreval("SUCESSO: Usuario logado > ", u)
      senao
         usr<-""
         escreval("ERRO: Senha incorreta")
      fimse
   senao
      escreval("ERRO: Usuario nao encontrado > ", u)
   fimse
fimprocedimento


procedimento cadastrar(u: caracter; p: caracter)
inicio
   escreval()
   se (k>100) entao
      escreval("ERRO: Limite de cadastros alcancado [101/101]")
   senao
      se (checkU(u) = falso) entao
         userV.userN[k]<-u
         userV.passW[k]<-p
         escreval(userV.userN[k])
         escreval(userV.passW[k])
         k<-k+1
         escreval("SUCESSO: Usuario cadastrado > ", u)
      senao
         escreval("ERRO: Usuario ja cadastrado > ", u)
      fimse
   fimse
fimprocedimento

funcao checkU(u: caracter): logico
var i: inteiro
inicio
   para i de 0 ate 100 faca
      se (userV.userN[i] = u) entao
         j<-i
         retorne verdadeiro
         interrompa
      senao
         retorne falso
      fimse
   fimpara
fimfuncao

procedimento logout
inicio
   escreval()
   se (aut = verdadeiro) entao
      aut<-falso
      usr<-""
      escreval("SUCESSO: Autenticacao finalizada")
   senao
      escreval("ERRO: Usuario nao autenticado")
   fimse
fimprocedimento

inicio

   aut<-falso
   k<-0

   enquanto (r<>9) faca

      escreval()
      
      escreval("-------------------------")
      
      se (aut=verdadeiro) entao
         escreval("Usuario: [",usr,"]")
      fimse

      escreval("1 - Login")
      escreval("2 - Registrar")
      escreval("3 - Logout")
      escreval("4 - Texto Para Fala")
      escreval("5 - Botoes Sentimento")
      escreval("9 - Finalizar")

      escreval("-------------------------")
      escreval("Informe a opcao desejada:")
      escreval("-------------------------")

      leia(r)
      escolha r
      caso 9
         escreval("..finalizando")
         interrompa
      caso 1
         se (aut = verdadeiro) entao
            escreval("ERRO: Usuario ja autenticado: ", usr)
            escreval("Efetue logout primeiro!")
         senao
            escreval("Informe o usuario:")
            leia(tuser)
            escreval("Informe a senha:")
            leia(tpw)
            login(tuser,tpw)
         fimse
      caso 2
         escreval("Informe o usuario:")
         leia(tuser)
         escreval("Informe a senha:")
         leia(tpw)
         cadastrar(tuser,tpw)
      caso 3
         logout
      caso 4
         escreval("ERRO: Nao implementado")
      caso 5
         escreval("ERRO: Nao implementado")
      outrocaso
         escreval("ERRO: Opcao invalida!")
         escreval("Pressione <enter> para retornar")
         leia(r)
      fimescolha

   fimenquanto

fimalgoritmo