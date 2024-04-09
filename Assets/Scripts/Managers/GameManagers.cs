using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class GameManagers : MonoBehaviour
{
   private int lvlIndex;
   
   private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

// Отписываемся от события GetDataEvent в OnDisable
   private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

   private void Start()
   {
      // Проверяем запустился ли плагин
      if (YandexGame.SDKEnabled == true)
      {
         // Если запустился, то выполняем Ваш метод для загрузки
         GetLoad();

         // Если плагин еще не прогрузился, то метод не выполнится в методе Start,
         // но он запустится при вызове события GetDataEvent, после прогрузки плагина
      }
   }

   public void NextLevel()
   {
      lvlIndex++;
      MySave();
   }

// Ваш метод для загрузки, который будет запускаться в старте
   private int _empty;
   public void GetLoad()
   {
      // Получаем данные из плагина и делаем с ними что хотим
      // Например, мы хотил записать в компонент UI.Text сколько у игрока монет:
      lvlIndex = YandexGame.savesData.levelIndex;
   }

// Допустим, это Ваш метод для сохранения
   public void MySave()
   {
      // Записываем данные в плагин
      // Например, мы хотил сохранить количество монет игрока:
      YandexGame.savesData.levelIndex = lvlIndex;

      // Теперь остаётся сохранить данные
      YandexGame.SaveProgress();
   }
}
