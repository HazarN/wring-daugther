require('dotenv').config();
const { spawn } = require('child_process');

const PORT = process.env.EXPO_PORT;

const expo = spawn('npx', ['expo', 'start', '--port', PORT], { stdio: 'inherit', shell: true });

expo.on('close', (code) => console.log(`Expo process exited with code ${code}`));
