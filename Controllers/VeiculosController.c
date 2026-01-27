#include <stdio.h>
#include <string.h>

#define MAX 100

// USO DE ENUMS PARA REPRESENTAR VALORES POSSÍVEIS NA INSERÇÃO DOS DADOS, EVITANDO USO DE VALORES INVÁLIDOS.
typedef enum{
GASOLINA,
ALCOOL,
DIESEL,
ELETRICO
}TipoDeCombustivel;

typedef enum{
PASSEIO,
SUV,
CAMINHAO,
MOTO
}CategoriaDoVeiculo;

// STRUCT QUE CRIA A VARIÁVEL VEÍCULO, QUE ARMAZENA DIVERSOS DADOS REFERENTES A ELE (INCLUSIVE AS ENUMS, QUE CONTAM COMO DADOS ESSENCIAIS).
typedef struct{
int id;
char placa[10];
char marca[30];
char modelo[30];
int ano;
float capacidadeDoTanque;
TipoDeCombustivel combustivel;
CategoriaDoVeiculo categoria;
}Veiculo;

// SIMULA UM BANCO DE DADOS, ARMAZENANDO TEMPORARIAMENTE NA RAM OS DADOS CADASTRADOS NA EXECUÇÃO DO PROGRAMA.
Veiculo veiculos[MAX];
int total = 0;
int proximoId = 1;

// FUNÇÃO AUXILIAR DE BUSCA DE VEÍCULO POR SEU ID. COMPARA O ID INSERIDO COM OS EXISTENTES.
int buscarPorId(int id){
   for(int i = 0; i < total; i++){
      if(veiculos[i].id == id){
      return i;
      }
   }
return -1;
}

// INÍCIO DA CRUD
// INDEX (UTILIZA LAÇO FOR PRA PERCORRER OS VEÍCULOS E IMPRIMIR UM POR UM):
void listagemVeiculos(){
   if(total == 0){
      printf("Nenhum veículo cadastrado.\n");
      return;
   }
   printf("Lista de Veículos:");
   for(int i = 0; i < total; i++){
       printf("ID: %d | %s %s | Placa: %s", veiculos[i].id, veiculos[i].marca, veiculos[i].modelo, veiculos[i].placa);
   }
}

// DETAILS (É USADO IDX E NÃO I POIS IDX REPRESENTA O ÍNDICE DO VEÍCULO ENCONTRADO; I É APENAS CONTROLE DO LAÇO DE REPETIÇÃO):
void detalhesVeiculo(){
   int id;
   printf("Informe o ID do veículo: ");
   scanf("%d", &id);

   int idx = buscarPorId(id);
   if(idx == -1){
      printf("Veículo não encontrado.");
      return;
   }

   Veiculo v = veiculos[idx];

   printf("Detalhes: ");
   printf("ID: %d", v.id);
   printf("Marca: %s", v.marca);
   printf("Modelo: %s", v.modelo);
   printf("Placa: %s", v.placa);
   printf("Ano: %d", v.ano);
   printf("Capacidade do tanque: %.2f", v.capacidadeTanque);
   printf("Combustível: %d", v.combustivel);
   printf("Categoria: %d", v.categoria);
}

// CREATE (USA INT* EM COMBUSTÍVEL E CATEGORIA POIS FAZEM PARTE DE UMA ENUM, LOGO O INT* TRATA ELES COMO UM INTEIRO):
void criarVeiculo(){
   if(total >= MAX){
      printf("Limite de veículos atingido.");
      return;
   }

   Veiculo v;
   v.id = proximoId++; // SIMULA UM AUTO INCREMENT PRIMARY KEY DE SQL.

   printf("Placa: ");
   scanf("%s", v.placa);

   printf("Marca: ");
   scanf("%s", v.marca);

   printf("Modelo: ");
   scanf("%s", v.modelo);

   printf("Ano: ");
   scanf("%d", &v.ano);

   printf("Capacidade do tanque: ");
   scanf("%f", &v.capacidadeTanque);

   printf("Combustível (0- Gasolina, 1- Álcool, 2- Diesel, 3- Elétrico): ");
   scanf("%d", (int*)&v.combustivel);

   printf("Categoria (0-Passeio, 1-SUV, 2-Caminhão, 3-Moto): ");
   scanf("%d", (int*)&v.categoria);

   veiculos[total] = v;
   total++; // INCREMENTA NO TOTAL DE VEÍCULOS CADASTRADOS, RESPEITANDO O MÁX DE 100 VEÍCULOS.

   printf("Veículo cadastrado com sucesso!");
}

// EDIT:
void editarVeiculo(){
   int id;
   printf("Informe o ID do veículo: ");
   scanf("%d", &id);

   int idx = buscarPorId(id);
   if(idx == -1){
      printf("Veículo não encontrado.");
      return;
   }

   printf("Nova placa: ");
   scanf("%s", veiculos[idx].placa);

   printf("Nova marca: ");
   scanf("%s", veiculos[idx].marca);

   printf("Novo modelo: ");
   scanf("%s", veiculos[idx].modelo);

   printf("Novo ano: ");
   scanf("%d", &veiculos[idx].ano);

   printf("Atualizado com sucesso!");
}

// DELETE:
void excluirVeiculo(){
   int id;
   printf("Informe o ID do veículo: ");
   scanf("%d", &id);

   int idx = buscarPorId(id);
   if(idx == -1){
      printf("Veiculo nao encontrado.\n");
      return;
   }

   for(int i = idx; i < total - 1; i++){ // REORGANIZA O ARRAY DE VEÍCULOS APÓS A EXCLUSÃO DE UM VEÍCULO.
       veiculos[i] = veiculos[i + 1];
   }

   total--;
   printf("Veículo excluído com sucesso!");
}

// FUNÇÃO MAIN QUE USA TODAS AS FUNÇÕES CRIADAS.
int main(){
   int opcao;

   do{
   printf("Menu de Veículos:");
   printf("1 - Listar");
   printf("2 - Detalhes");
   printf("3 - Criar");
   printf("4 - Editar");
   printf("5 - Excluir");
   printf("0 - Sair");
   printf("Opcão: ");
   scanf("%d", &opcao);

      switch(opcao){
         case 1: listarVeiculos(); break;
         case 2: detalhesVeiculo(); break;
         case 3: criarVeiculo(); break;
         case 4: editarVeiculo(); break;
         case 5: excluirVeiculo(); break;
         case 0: printf("Encerrando..."); break;
         default: printf("Opção inválida.");
      }
   } while(opcao != 0);

return 0;
}
