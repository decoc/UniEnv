# What is UniEnv

UniEnv help you to deal enviroment values such as password or token easily in Unity project while developing.　This Base idea is [dotnet-env](https://github.com/tonerdo/dotnet-env).

## Features

- It works `only in Editor` to avoid product include env file
- Env object suggest that `writing env path to .gitignore`
- You can write env settings directory as simple format texts

## How to Use

1. Env.asset under Plugins/UniEnv
2. Press `"+"` button to add new key value pair of enviroment values
3. Call env value from script as following

```cs
public void ReadFormValue(){
    var userId = UniEnv.Config["userId"];
    var password = UniEnv.Config["password"];
}
```

or

```cs
public void ReadFormValue(){
    var userId = UniEnv.Config.GetString("userId");
    var password = UniEnv.Config.GetString("password");
}
```

# UPM Package

You can add `https://github.com/decoc/UniEnv.git?path=Assets/Plugins` to Package Manager

## Licenses
This project is licensed under the MIT License - see the [LICENSE.txt](./LICENSE.txt) file for details.

## Dependencies

This library depends on [UnitySerializedDictionary](https://github.com/Prastiwar/UnitySerializedDictionary) to manage key-value pairs in Unity. In the future update, it may be remove due to official support serializable dictionary. [See more](https://forum.unity.com/threads/dictionary-serialization.915947/)
