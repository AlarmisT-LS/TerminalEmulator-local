using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalEmulator
{

    class Terminal
    {
        private string name;
        private string password;
        private bool flagPassword;

        public Terminal()
        {
            name = "Terminal";
            flagPassword = false;
        }
        //Пользовательский режим
        public void CustomMode()
        {
            while (flagPassword)
            {
                if (password == CommandEntry(".password:"))
                    break;
            }
            bool exit = false;
            while (exit != true)
            {
                switch (CommandEntry(">"))
                {
                    case "enable":
                        PrivilegedMode();
                        break;
                    case "path":
                        Console.WriteLine($"{name}>path CustomMode");
                        break;
                    //Добавить команды
                    case "exit":
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
        //Привилегированный режим
        private void PrivilegedMode()
        {
            bool exit = false;
            while (exit != true)
            {
                switch (CommandEntry("#"))
                {
                    case "hostname":
                        TerminalNameEditor();
                        break;
                    case "password":
                        TerminalPasswordEditor();
                        break;
                    case "login":
                        TerminalFlagPassword();
                        break;
                    case "path":
                        Console.WriteLine($"{name}#path CustomMode -> PrivilegedMode");
                        break;
                    //Добавить команды
                    case "disable":
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
        //Ввод команды
        private string CommandEntry(string label)
        {
            Console.Write($"{name}{label}");
            return Console.ReadLine();
        }
        //Редактирование имени терминала
        private void TerminalNameEditor()
        {
            name = CommandEntry("#Enter new name:");
        }
        //Редактирование пароля терминала при входе
        private void TerminalPasswordEditor()
        {
            string pas = CommandEntry("#Enter new password:");
            if (pas.Length > 0)
                password = pas;
            else
            {
                password = null;
                flagPassword = false;
            }
                
        }
        //Включение/выключение ввода пароля
        private void TerminalFlagPassword()
        {
            if (password != null)
            {
                if (password.Length > 0)
                {
                    if (flagPassword == false)
                    {
                        Console.WriteLine($"{name}#login ON");
                        flagPassword = true;
                        
                    }
                    else
                    {
                        Console.WriteLine($"{name}#login OFF");
                        flagPassword = false;
                    }
                }
            }

        }
    }
}
