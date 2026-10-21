const fs = require('fs').promises;
const readline = require('readline');

// 1. Чтение параметров командной строки
const args = process.argv.slice(2);
console.log('Аргументы командной строки:', args);

// 2. Интерактивный ввод с клавиатуры
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question('Введите текст для сохранения в файл: ', async (text) => {
    try {
        // 3. Запись данных в файл
        await fs.writeFile('output.txt', text);
        console.log('Данные успешно записаны в output.txt');

        // 4. Чтение данных из файла
        const data = await fs.readFile('output.txt', 'utf8');
        console.log('Содержимое файла:', data);
    } catch (err) {
        console.error('Ошибка при работе с файлом:', err);
    } finally {
        rl.close(); // Важно закрывать интерфейс
    }
});