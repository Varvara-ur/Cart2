using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CardsApp
{
    public partial class MainWindow : Window
    {
        private List<Card> originalCards;
        private List<Card> currentCards;
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            InitializeCards();
        }

        // Инициализация списка карт
        private void InitializeCards()
        {
            originalCards = new List<Card>
            {
                new Card { Key = 1, Name = "КолесоФортуны" },
                new Card { Key = 2, Name = "Жрец" },
                new Card { Key = 3, Name = "Башня" },
                new Card { Key = 4, Name = "Жрица" },
                new Card { Key = 5, Name = "Сила" },
                new Card { Key = 6, Name = "Умеренность" },
                new Card { Key = 7, Name = "Влюбленные" },
                new Card { Key = 8, Name = "Отшельник" },
                new Card { Key = 9, Name = "Мир" },
                new Card { Key = 10, Name = "Смерть" },
                new Card { Key = 10, Name = "Башня" }
            };

            currentCards = new List<Card>(originalCards);
            UpdateCardsList();
        }

        // Обновление отображаемого списка
        private void UpdateCardsList()
        {
            CardsListBox.ItemsSource = null;
            CardsListBox.ItemsSource = currentCards;
        }

        // Перемешивание карт
        private void Shuffle_Click(object sender, RoutedEventArgs e)
        {
            currentCards = currentCards.OrderBy(c => random.Next()).ToList();
            UpdateCardsList();
        }

        // Сортировка по имени
        private void SortByName_Click(object sender, RoutedEventArgs e)
        {
            currentCards = currentCards.OrderBy(c => c.Name).ToList();
            UpdateCardsList();
        }

        // Возврат к исходному порядку
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            currentCards = new List<Card>(originalCards);
            UpdateCardsList();
        }

        // Поиск карты по названию
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                currentCards = originalCards
                    .Where(c => c.Name.ToLower().Contains(searchText.ToLower()))
                    .ToList();
                UpdateCardsList();
            }
        }

        // Показать все карты
        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            currentCards = new List<Card>(originalCards);
            UpdateCardsList();
            SearchTextBox.Text = "";
        }
    }
}