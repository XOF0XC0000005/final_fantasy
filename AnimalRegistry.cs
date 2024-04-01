﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace final_fantasy
{
    internal class AnimalRegistry
    {
        public List<Animal> animals = new List<Animal>();

        public void Open()
        {
            const string AddAnimalCommand = "1";
            const string ShowAllAnimalsCommand = "2";
            const string ShowAllAnimalsByDateCommand = "3";
            const string ShowAnimalCounterCommand = "4";
            const string ExitCommand = "5";

            bool isOpen = true;
            string userInput;

            while (isOpen)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в реестр животных!\n");
                Console.WriteLine("Выберите пункт меню: ");
                Console.WriteLine($"{AddAnimalCommand}.Добавить новое животное.");
                Console.WriteLine($"{ShowAllAnimalsCommand}.Показать всех животных.");
                Console.WriteLine($"{ShowAllAnimalsByDateCommand}.Показать всех животных по дате рождения.");
                Console.WriteLine($"{ShowAnimalCounterCommand}.Показать количество животных в реестре.");
                Console.WriteLine($"{ExitCommand}.Выйти из реестра.");

                Console.Write("Номер команды:");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddAnimalCommand:
                        AddAnimal();
                        break;
                    case ShowAllAnimalsCommand:
                        ShowAllAnimals();
                        break;
                    case ShowAllAnimalsByDateCommand:
                        ShowAllAnimalsByDate();
                        break;
                    case ShowAnimalCounterCommand:
                        ShowAnimalCounter();
                        break;
                    case ExitCommand:
                        isOpen = false;
                        break;
                }
            }      
        }

        private void AddAnimal()
        {
            const string AddDogCommand = "1";
            const string AddCatCommand = "2";
            const string AddHamsterCommand = "3";
            const string AddHorseCommand = "4";
            const string AddCamelCommand = "5";
            const string AddDonkeyCommand = "6";

            string userInput;

            Console.Clear();
            Console.WriteLine("Какое животное вы хотите добавить?");
            Console.WriteLine($"{AddDogCommand}.Собака");
            Console.WriteLine($"{AddCatCommand}.Кошка");
            Console.WriteLine($"{AddHamsterCommand}.Хомяк");
            Console.WriteLine($"{AddHorseCommand}.Лошадь");
            Console.WriteLine($"{AddCamelCommand}.Верблюд");
            Console.WriteLine($"{AddDonkeyCommand}.Осел");
            Console.Write("Введите номер команды:");

            userInput = Console.ReadLine();

            switch(userInput)
            {
                case AddDogCommand:
                    AddCorrectAnimal("Dog");
                    break;
                case AddCatCommand:
                    AddCorrectAnimal("Cat");
                    break;
                case AddHamsterCommand:
                    AddCorrectAnimal("Hamster");
                    break;
                case AddHorseCommand:
                    AddCorrectAnimal("Horse");
                    break;
                case AddCamelCommand:
                    AddCorrectAnimal("Camel");
                    break;
                case AddDonkeyCommand:
                    AddCorrectAnimal("Donkey");
                    break;
            }
        }

        private void ShowAllAnimals()
        {
            Console.Clear();
            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine($"{i}.{animals[i].Name}");
            }

            Console.WriteLine("\nВведите индекс животного, чтобы просмотреть его команды.");

            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int index))
            {
                if (index >= animals.Count || index < 0) Console.WriteLine("Введите корректный индекс!");
                else
                {
                    Animal currentAnimal = animals[index];

                    Console.Write($"{currentAnimal.Name} знает: ");

                    foreach (var command in currentAnimal.Commands)
                    {
                        Console.Write(command + " ");
                    }

                    Console.Write("\nХотите добавить новые команды? Y/любая клавиша:");
                    userInput = Console.ReadLine();

                    string done = string.Empty;
                    List<string> animalCommands = new List<string>();

                    if (userInput.Equals("Y"))
                    {
                        Console.WriteLine("Вводите команды по одной, если вы захотите закончить ввод комманд, введите exit");

                        while (!done.Equals("exit"))
                        {
                            Console.Write("\nВведите команду, которые знает животное: ");
                            done = Console.ReadLine();

                            if (!done.Equals("exit")) currentAnimal.Commands.Add(done);
                        }
                    }
                }
            }
            else Console.WriteLine("Введите корректный индекс");
            
        }

        private void ShowAllAnimalsByDate()
        {
            Console.Clear();
            Console.Write("Введите дату рождения по которой будут искаться животные: ");
            string userInput = Console.ReadLine();

            foreach (var animal in animals)
            {
                if (DateTime.Equals(animal.DateOfBirth, DateTime.ParseExact(userInput, "MM.dd.yyyy", null)))Console.WriteLine(animal.Name + " " + animal.Type + " " + animal.DateOfBirth);
            }

            Console.WriteLine("Нажмите, чтобы продолжить");
            Console.ReadLine();
        }

        private void ShowAnimalCounter()
        {
            Console.Clear();
            Console.Write($"В реестре животных: {animals.Count}");
            Console.Write("\n Нажмите, чтобы продолжить");
            Console.ReadLine();
        }

        private void AddCorrectAnimal(string type)
        {
            Console.Clear();
            Console.Write("Введите кличку: ");
            string name = Console.ReadLine();
            Console.Write("Введите дату рождения в формате mm.dd.yyyy: ");
            string dateOfBirth = Console.ReadLine();

            string done = string.Empty;
            List<string> animalCommands = new List<string>();

            Console.WriteLine("Вводите команды по одной, если вы захотите закончить ввод комманд, введите exit");

            while (!done.Equals("exit"))
            {
                Console.Write("\nВведите команду, которые знает животное: ");
                done = Console.ReadLine();

                if (!done.Equals("exit")) animalCommands.Add(done);
            }

            if (type.Equals("Dog")) animals.Add(new Dog(name, type, DateTime.ParseExact(dateOfBirth, "MM.dd.yyyy", null), animalCommands));
            else if(type.Equals("Cat")) animals.Add(new Cat(name, type, DateTime.ParseExact(dateOfBirth, "MM.dd.yyyy", null), animalCommands));
            else if (type.Equals("Hamster")) animals.Add(new Hamster(name, type, DateTime.ParseExact(dateOfBirth, "MM.dd.yyyy", null), animalCommands));
            else if (type.Equals("Horse")) animals.Add(new Horse(name, type, DateTime.ParseExact(dateOfBirth, "MM.dd.yyyy", null), animalCommands));
            else if (type.Equals("Camel")) animals.Add(new Camel(name, type, DateTime.ParseExact(dateOfBirth, "MM.dd.yyyy", null), animalCommands));
            else if (type.Equals("Donkey")) animals.Add(new Donkey(name, type, DateTime.ParseExact(dateOfBirth, "MM.dd.yyyy", null), animalCommands));

            Console.Clear();
            Console.WriteLine("Животное добавлено!");
        }
    }
}
