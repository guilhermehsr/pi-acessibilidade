import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {

  constructor() {}

  variavel_lista = [];
  variavel_valor = [];
  texto: string = "";
  valor: number;
  soma: number = 0;

  adiciona() {
    if (!(this.texto == "")) {
      this.variavel_lista.push(this.texto);
      this.texto = "";

      this.variavel_valor.push(this.valor);
      this.valor = null;
    }

    this.soma = 0;

    for (var i = 0; i < this.variavel_valor.length; i++) {
      this.soma = this.soma + parseInt(this.variavel_valor[i]);
      console.log(this.variavel_valor[i])
    }
   
  }

  remove(indice) {
    this.soma = this.soma - parseInt(this.variavel_valor[indice]);
    this.variavel_lista.splice(indice, 1)
    this.variavel_valor.splice(indice, 1)

    console.log(parseInt(this.variavel_valor[indice]))
  }

}
