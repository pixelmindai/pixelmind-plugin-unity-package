# Pixelmind SDK

Unity package that allows you to generate infinite game assets using AI.

## Install

Open `Packages/manifest.json` with your favourite editor and add the following in your `dependencies` (make sure to respect JSON commas):

```json
{
 "dependencies": {
  "com.pusher.pusherwebsocketunity": "https://github.com/pusher/pusher-websocket-unity.git#upm",
  "ai.330.pixelmindgenerator": "https://github.com/pixelmindai/pixelmind-plugin-unity-package.git#develop"
 }
}
```

## Getting Started

### Editor

1. Select a game object
2. Click 'Add Component' in the 'Inspector' window
3. Type 'Pixelmind Generator' and add the component
4. Click 'Get generators'
5. Enter a texture description, for example 'plasma gun'
6. If you don't want the sprite to be modified, uncheck 'Assign To Sprite Renderer'
7. Click 'Generate'
8. Optionally you can save your texture as a prefab now

### Runtime

1. Click on the 'Enable GUI' button
2. Use the in-game form the same way as mentioned above in the editor section.







