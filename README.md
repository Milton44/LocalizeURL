# LocalizeURL

Uma forma de organizar e separar os tipos de URLs de teste e de produção. Ainda conta com uma melhoramento da montagem da URL com acréscimo de parâmetros de forma automática.

## Comandos
![image](https://user-images.githubusercontent.com/30666775/125294827-009eae00-e2fb-11eb-9188-ba34edb3ebe3.png)

1. Chave da URL a ser escolhida.
2. Adicionar nova chave de URL(será redirecionado para a janela de configurações gerais da API).
3. Colocar parâmetros personalizados na URL
4. Caractere usado para separar um parâmetro de outro parâmetro
5. Caractere usado para separar um parâmetro(key) do valor(value) ao qual está sendo atribuído
6. Uma preview da URL base de produção
7. Uma preview da URL base de teste
8. Uma preview da URL base escolhida com os parâmetros

## Criando uma URL
1. Na barra de ferramentas da Unity vá em **Window->Localize URL**

![image](https://user-images.githubusercontent.com/30666775/125302247-27141780-e302-11eb-8d58-32da370c8ad9.png)

2. Irá abrir uma janela com as configurações gerais das URLs. A opção "Test Mode" na aba **Geral** irá definir qual URLs, se ativada será a URL de teste e caso esteja desativada será a de produção.

![image](https://user-images.githubusercontent.com/30666775/125302712-9558da00-e302-11eb-9e22-1b2ae3bee9f9.png)

3.  Ao selecionar a aba **Value** irá aparece um dicionário e para adicionar uma nova URL basta apertar no botão **+**

![image](https://user-images.githubusercontent.com/30666775/125303276-11532200-e303-11eb-9b4e-4c9d479bfd8e.png)

4. Agora basta escolher um id para a URL, por exmplo, usei o id "TesteURL". E agora basta adicionar seus respectivosvalores de URL de produção e teste.

![image](https://user-images.githubusercontent.com/30666775/125303891-86bef280-e303-11eb-8198-24b7cb202ba8.png)

## Recuperando a URL

Para recuperar e personalizar uma URL base com parâmetros basta seguir os seguintes passos

1. Inicialmente é necessário criar uma variável do tipo URLId em um script Monobehaviour utilizando a biblioteca LocalizeURL, como exmplificado no script de exemplo "GetURLExample.cs".

![image](https://user-images.githubusercontent.com/30666775/125305471-bc181000-e304-11eb-8859-36b8b6b07aeb.png)

2. Agora no inspector anexe o script GetURLExample.cs em um GameObject e observe à variável URLId. Escolha a key da URL recém criada.

![image](https://user-images.githubusercontent.com/30666775/125305816-0dc09a80-e305-11eb-9a2b-b349c98a8789.png)

3. Ative o "Custom Params" para ativar os parâmetros personalizados na URL base

![image](https://user-images.githubusercontent.com/30666775/125306324-7d368a00-e305-11eb-8b3a-cb5c551961b0.png)

4. Adcione os seguintes parâmetros "param_0", "param_1" e "param_3".

![image](https://user-images.githubusercontent.com/30666775/125306686-c981ca00-e305-11eb-9aed-a9729c536a6e.png)

5. Agora vamos voltar ao script "GetURLExample.cs" e na função Start adicione o Debug.Log(urlId.GetURLFormat("value_0","value_1", 3)) para recuperar a URL com os parâmetros. Mas caso deseje recuperar apenas a URL base retorne ao passo 3 e desative o "Custom Params" e por fim adicione no Start Debug.Log(urlId.GetURL());

![image](https://user-images.githubusercontent.com/30666775/125308790-92141d00-e307-11eb-9f91-8c9cb3a8515f.png)

**OU**(caso os parâmetros customizados esteja desativados)

![image](https://user-images.githubusercontent.com/30666775/125307338-5b89d280-e306-11eb-9c75-937cf7145376.png)

6. Agora você pode testar ativando ou desativando o "Test Mode" para ver as saídas de URL no console da Unity ao apertar o play.




