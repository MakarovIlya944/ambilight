#define NUM_LEDS 92          // число светодиодов в ленте
#define DI_PIN 13            // пин, к которому подключена лента
#define OFF_TIME 5          // время (секунд), через которое лента выключится при пропадаании сигнала
#define CURRENT_LIMIT 1000   // лимит по току в миллиамперах, автоматически управляет яркостью (пожалей свой блок питания!) 0 - выключить лимит

#define START_FLASHES 1      // проверка цветов при запуске (1 - включить, 0 - выключить)

int new_bright, new_bright_f;
unsigned long bright_timer, off_timer;
char data = 0;
#define serialRate 38400  // скорость связи с ПК
#include <FastLED.h>
CRGB leds[NUM_LEDS];  // создаём ленту
boolean led_state = true;  // флаг состояния ленты

void setup() {
  FastLED.addLeds<WS2812, DI_PIN, GRB>(leds, NUM_LEDS);  // инициализация светодиодов
  if (CURRENT_LIMIT > 0) FastLED.setMaxPowerInVoltsAndMilliamps(5, CURRENT_LIMIT);

  // вспышки красным синим и зелёным при запуске (можно отключить)
  if (START_FLASHES) {
    LEDS.showColor(CRGB(20, 0, 0));
    delay(500);
    LEDS.showColor(CRGB(0, 20, 0));
    delay(500);
    LEDS.showColor(CRGB(0, 0, 20));
    delay(500);
    LEDS.showColor(CRGB(0, 0, 0));
  }

  Serial.begin(serialRate);
}

void check_connection() {
  if (led_state) {
    if (millis() - off_timer > (OFF_TIME * 1000)) {
      led_state = false;
      FastLED.clear();
      FastLED.show();
    }
  }
}

void loop() {

  data = 0;
  Serial.print("E");
  while(data!='B'){
    while (!Serial.available()) check_connection();;
    data = Serial.read();
  }

  if (!led_state) led_state = true;
  off_timer = millis();  
  memset(leds, 0, NUM_LEDS * sizeof(struct CRGB));
  for (int i = 0; i < NUM_LEDS; i++) {
    byte r, g, b;
    // читаем данные для каждого цвета
    while (!Serial.available()) check_connection();;
    r = Serial.read();
    while (!Serial.available()) check_connection();;
    g = Serial.read();
    while (!Serial.available()) check_connection();;
    b = Serial.read();
    leds[i].r = r;
    leds[i].g = g;
    leds[i].b = b;
  }  
  FastLED.show();  // записываем цвета в ленту
}
