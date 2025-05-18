using SevenFoodApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.Util
{
    public class Please
    {
        public static void StartDataBase() =>
            FileRepository.StartFiles();

        public static int GetNextId() =>
            FileRepository.getLastId() + 1;

        public static string GetMessageGenericError(string moreMessage = "") =>
            $"Eita, algo de errado não está certo...{moreMessage}";

        public static string GetMessageInvalidOption(bool tryAgain = false) =>
            $"Opção Inválidade! {(tryAgain ? "Tente novamente..." : "")}";

        public static string GetTitle(string action, string context) =>
            $"{action} {context}";

        public static string ChoiceOption() =>
            "Escolha uma Opção";

        public static string TranslateFromBool(bool value) =>
            value ? "Sim" : "Não";

        public static bool TranslateToBool(string value) =>
            value.ToLower() == "sim";

        public static string ConsoleRead() => Console.ReadLine()!.Replace(";", "");
    }
}
