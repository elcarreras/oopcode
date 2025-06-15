@echo off

:: Проверяем, установлен ли Git
where git >nul 2>nul
if %errorlevel% neq 0 (
    echo Git не установлен. Установите Git для продолжения.
    pause
    exit /b 1
)

:: Переходим в текущую директорию (если это необходимо)
cd "%~dp0"

:: Переименовываем все файлы, добавляя расширение .cs
for %%f in (*) do (
    if not "%%~xf" == ".bat" (
        ren "%%f" "%%~nf.cs"
    )
)

:: Инициализируем локальный Git-репозиторий
git init

:: Добавляем все файлы в репозиторий
git add .

:: Создаем коммит
git commit -m "Initial commit"

:: Устанавливаем ссылку на удаленный репозиторий
git remote add origin https://github.com/elcarreras/oopcode.git 

:: Отправляем все изменения на GitHub
git push -u origin master

:: Сообщаем о завершении
echo Все файлы успешно загружены на GitHub.
pause