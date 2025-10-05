# ✨ Messenger — ASP.NET Core Real-Time Experience

![.NET 5](https://img.shields.io/badge/.NET-5.0-512BD4?style=for-the-badge&logo=.net)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-RealTime-646CFF?style=for-the-badge&logo=visual-studio)
![SignalR](https://img.shields.io/badge/SignalR-Synchronized-2E8B57?style=for-the-badge&logo=signal&logoColor=white)
![EF Core](https://img.shields.io/badge/EF%20Core-6F42C1?style=for-the-badge&logo=entity-framework)
![JWT](https://img.shields.io/badge/Auth-JWT-FF6B6B?style=for-the-badge&logo=json-web-tokens)
![JavaScript](https://img.shields.io/badge/Frontend-JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=000)

> _«Интернет полон шума. Aurora Messenger — это тот самый голос, которому хочется ответить.»_

---

## 🚀 Что это за приложение?

**Messenger** — современный веб-мессенджер на ASP.NET Core (.NET 5), который соединяет людей мгновенно и стильно. Вы получите:

- ⚡ **Переписку в реальном времени** благодаря SignalR  
- ❤️ **Реакции и лайки** на сообщения и медиа  
- 📷 **Загрузку и предпросмотр фотографий**  
- 👥 **Список друзей и систему дружбы**  
- 🔔 **Мгновенные уведомления** (toast и in-app)  
- 👤 **Персональные страницы пользователей** с кастомизацией  
- 🛡️ **JWT-аутентификацию** для безопасного доступа  

---

## 🧬 Технологический стек

| Слой             | Технология                              | Назначение                                       |
|------------------|------------------------------------------|--------------------------------------------------|
| Backend          | ASP.NET Core 5                           | REST API, бизнес-логика, маршрутизация           |
| Real-Time        | SignalR                                  | WebSocket-подключения, мгновенная синхронизация  |
| Data Access      | Entity Framework Core + SQL Server       | ORM, миграции, LINQ, транзакции                  |
| Auth             | JWT + ASP.NET Identity                   | Авторизация, refresh tokens, security middleware |
| Frontend         | JavaScript (ES6+, fetch, SignalR JS)     | SPA/MPA-интерфейс, интерактивные компоненты      |
| Storage          | Azure Blob / локальное хранилище         | Фото, медиаконтент                               |
| Infrastructure   | Docker, CI/CD (GitHub Actions)           | Сборка, тесты, деплой                            |

---

## 🧪 Основные модули

### 🔐 AuthenticationManager
- Регистрация/логин с e-mail/паролем  
- Refresh Tokens + Sliding Expiration  
- Проверка e-mail, восстановление пароля  

### 💬 Messanger
- Реальные комнаты чата  
- One-to-one и групповые беседы  
- Присоединение/отключение с индикацией присутствия  
- Уведомления о прочтении, наборе текста, доставке  

### 🧑‍🤝‍🧑 UserManager
- Поиск и добавление друзей  
- Настройки приватности  
- Фото профиля, галерея, статусы  
- Лента событий: лайки, комментарии, добавления в друзья  

---

## 📦 Быстрый старт

```bash
git clone https://github.com/SurmDen/Messanger.git
cd aurora-messenger

# 1. Миграции и база
dotnet ef database update

# 2. Запуск backend
dotnet run --project Messanger
