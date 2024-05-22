using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;


namespace Stats_system
{
    public static class StatsController
    {
        private static string apiUrl = "http://45.12.74.4/api/anatoly-statistics/";

        
        public static Stats[] currentStats;
        public static Stats newStats;
        
        public static void SendStatsInServer(Stats stats)
        {
            // Сериализация данных в JSON
            string json = JsonUtility.ToJson(stats);

            // Создание нового запроса UnityWebRequest для отправки данных методом POST
            UnityWebRequest request = new UnityWebRequest(apiUrl, "POST")
            {
                uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json)), // Установка тела запроса
                downloadHandler = new DownloadHandlerBuffer(), // Получение ответа от сервера
                disposeDownloadHandlerOnDispose = true, // Автоматическое управление памятью
                disposeUploadHandlerOnDispose = true // Автоматическое управление памятью
            };

            request.SetRequestHeader("Content-Type", "application/json"); // Установка заголовка для контента типа JSON

            // Асинхронная отправка запроса и обработка ответа
            var operation = request.SendWebRequest();
            operation.completed += _ =>
            {
                if (request.isNetworkError || request.isHttpError) // Проверка на наличие ошибок
                {
                    Debug.LogError("Ошибка при отправке статистики: " + request.error);
                }
                else // В случае успеха
                {
                    Debug.Log("Статистика успешно отправлена: " + request.downloadHandler.text);
                }
            };
        }

  

        public static IEnumerator GetStats()
        {
            string apiUrlForGet = "http://45.12.74.4/api/anatoly-statistics/top/"; // Укажите правильный URL
            using(UnityWebRequest request = UnityWebRequest.Get(apiUrlForGet))
            {
                Debug.Log("khviuovoiuyv");
                yield return request.SendWebRequest();

                if (request.isNetworkError || request.isHttpError)
                {
                    Debug.LogError("Ошибка при получении статистики: " + request.error);
                }
                else
                {
                    Debug.Log("Статистика успешно получена: " + request.downloadHandler.text);
                    var json = request.downloadHandler.text;
                    currentStats = JsonHelper.FromJson<Stats>(json);
                }
            }
        }

    }
        public static class JsonHelper
        {
            public static T[] FromJson<T>(string json)
            {
                string newJson = "{ \"array\": " + json + "}";
                Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
                return wrapper.array;
            }

            [Serializable]
            private class Wrapper<T>
            {
                public T[] array;
            }
        }
}
