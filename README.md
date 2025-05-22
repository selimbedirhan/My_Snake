# 🐍 Pixel Snake Game

Bu proje, klasik Snake oyununu modern Unity ortamında yeniden canlandırır.  
Retro stil gri piksel duvarlar, dinamik hız sistemi ve ses efektleri ile sade ama zengin bir oyun deneyimi sunar.

---

## 🎮 Oynanış

- W, A, S, D tuşlarıyla yılanı kontrol et  
- Her yem yediğinde yılan uzar ve skor artar  
- Yılan her yemden sonra biraz daha hızlanır ⚡  
- Duvara veya kendine çarptığında oyun sona erer  
- Space tuşuna basarak oyunu yeniden başlatabilirsin 🔁

---

## 🧠 Özellikler

- ✅ **Retro Görsel Stil**: Gri piksel duvarlarla sade, nostaljik görünüm  
- ✅ **Dinamik Hızlanma**: Her yemle yavaş yavaş hız artar  
- ✅ **Skor Sistemi**: Anlık skor ve en yüksek skor gösterimi  
- ✅ **Ses Efektleri**:  
  - Yem yendiğinde `eat.wav` çalar  
  - Çarpma durumunda `crash.wav` çalar  
- ✅ **Game Over Ekranı**:  
  - TMP Text ile “Game Over” yazısı  
  - Restart butonu ve Space tuşu desteği

---

## 🗂️ Dosya Yapısı

- `Snake.cs` – Yılanın yön kontrolü, hareketi, büyümesi  
- `Food.cs` – Rastgele yem pozisyonu ve çarpışma  
- `GameManager.cs` – Skor, Game Over, yeniden başlatma  
- `SnakeEffects.cs` – Ses efektlerini tetikler  

---

## 🛠️ Kurulum

1. Unity 2D projesi oluştur  
2. `Assets` içinde `Scripts`, `Prefabs`, `Sprites`, `Audio` klasörleri oluştur  
3. Tüm script dosyalarını `Scripts` klasörüne yerleştir  
4. TMP (TextMeshPro) ekleyerek skor, yüksek skor ve Game Over UI’sini kur  
5. Ses dosyalarını (`eat.wav`, `crash.wav`) `Audio` klasörüne koy ve `SnakeEffects` objesine ata  
6. Sahneye şu objeleri yerleştir:  
   - `Snake`  
   - `Food`  
   - `GameManager`  
   - `SnakeEffects`  

---

## 🎨 Gereken Assetler

- Gri pixel görünümde kare sprite (`WallTile`)  
- `eat.wav` → Yem yeme sesi  
- `crash.wav` → Çarpma sesi  
- TextMeshPro (UI öğeleri için)

---




