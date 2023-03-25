using System.Globalization;
using Jogo_da_velha.Logica_jogo;
using Jogo_da_velha.UI;

Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("pt-BR");

while (true)
{
    var consoleGame = new ConsoleGame();
    consoleGame.Inicializar();
    consoleGame.Rodar();

    if (UI.PerguntarNovoJogo())
    {
        UI.LimparTela();
        continue;
    }

    break;
}
