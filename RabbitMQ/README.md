# RabbitMQ

## Propósito

O objetivo deste projeto é configurar dois aplicativos que se conectem à porta padrão do Rabbit (5672) e demonstrem seu funcionamento.

## Projeção do sistema

Quando o comando `dotnet run` é excecutado no projeto "Send", ele esta programado para enviar 5 mensagens para o "Receive".
O "Send" está configurado para persistir as mensagens em cache (disco) para minimizar a perda de informações em caso de falha no envio.
O "Receive" por sua vez, esta configurado para aguardar 1 segundo para cada "." encontrado na mensagem recebida, simulando um processo até que seja concluído.
Além disso, cada worker (receive) foi configurado para processar uma requisição por vez.

## Comandos necessários

```
1. cd Receive
2. dotnet run
2.1 Pode-se abrir duas instâncias para simular dois workers nesse momento.
3. cd ../Send
4. dotnet run
```
