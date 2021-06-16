# VibrationManager
Android、iOS端末でのバイブ機能  

## 使い方
VibrationManager.csのPlayVibration関数を呼ぶ    
  
## バイブの種類の設定方法
VibrationManager.csを編集する    
      
**共通**  
下記に種類を追加・削除
```cs
/// <summary>
/// バイブレーションのタイプ
/// </summary>
public enum VibrationType
{
    VeryShort,
    Short,
    Medium,
    Long,
}
```
    
**Android**  
下記にバイブレーションの種類と秒数(ミリ秒)を追加
```cs
//バイブレーションのタイプと時間（ミリ秒）
private static readonly Dictionary<VibrationType, long> VibrationTypeDic = new Dictionary<VibrationType, long>()
{
    { VibrationType.VeryShort,  100 },
    { VibrationType.Short,      300 },
    { VibrationType.Medium,     500 },
    { VibrationType.Long,       900 },
};

```
  
**iOS**  
下記にバイブレーションの種類とiOSのサウンドIDを追加  
※サウンドIDの一覧がよくわからなかったため現状は調べたサイトなどで紹介されていたIDを使用している。（どこにあるの一覧・・・）
```cs
//バイブレーションのタイプとiOSのサウンドID
private static readonly Dictionary<VibrationType, int> VibrationTypeDic = new Dictionary<VibrationType, int>()
{
    { VibrationType.VeryShort,  1519 },
    { VibrationType.Short,      1519 },
    { VibrationType.Medium,     1520 },
    { VibrationType.Long,       1521 },
};
```
