const int buttonpinStart = 13;  // Starten knappen ligger på nr 13
int buttonStateStart = 0;       // Sætter værdien for knappen
const int ldrPin = A0;          // Sensoren ligger på nr Analog 0 define photo interrupter signal pin
int ldrStatus;

// LED'en ligger på 12, og A,B,C,D er motoren, som har hver deres tal. Se på det som nord, syg, øst og vest
#define LED 12
#define A 8
#define B 9
#define C 10
#define D 11

void setup()
{
  Serial.begin(9600);               // Hvor ofte vores loop kører
  pinMode(buttonpinStart, INPUT);   // Sætter startknappen til et input
  pinMode(ldrPin, INPUT);           // Sætter sensoren til et input
  pinMode(LED, OUTPUT);             // Sætter leden til et output

  //Opsætning af motor som output
  pinMode(A,OUTPUT);
  pinMode(B,OUTPUT);
  pinMode(C,OUTPUT);
  pinMode(D,OUTPUT);
}

//Tilskrivning af motor output til de variabler vi satte i #define
void write(int a,int b,int c,int d){
  digitalWrite(A,a);
  digitalWrite(B,b);
  digitalWrite(C,c);
  digitalWrite(D,d);
}

//Metoden der læser input fra sensoren
void sensor(){
  if (ldrStatus <=400) {    // Hvis sensoren "opfanger" mindre end 400 lysmængde
  }
  else {                    // Hvis sensoren "opfanger" mere end 400 lysmængde
    //Serial.println("T");
    Serial.write(1);        // Sender vi 1, som unity kan læse
    Serial.flush();
    delay(5);
  }
}

//Metoden der får moteren til at spænde snoren ind
void onestep(){
  write(1,0,0,0);       // Hiver i nord
  delay(1);
  write(1,1,0,0);       // Hiver i nord-øst
  delay(1);
  write(0,1,0,0);       // Hiver i øst
  delay(1);
  write(0,1,1,0);       // Mv.
  delay(1);
  write(0,0,1,0);
  delay(1);
  write(0,0,1,1);
  delay(1);
  write(0,0,0,1);
  delay(1);
  write(1,0,0,1);
  delay(1);
}

//Metoden der får moteren til at spænde snoren ud
void revonestep(){
  write(1,0,0,1);
  delay(1);
  write(0,0,0,1);
  delay(1);
  write(0,0,1,1);
  delay(1);
  write(0,0,1,0);
  delay(1);
  write(0,1,1,0);
  delay(1);
  write(0,1,0,0);
  delay(1);
  write(1,1,0,0);
  delay(1);
  write(1,0,0,0);
  delay(1);
}

void loop()
{
  // Knappen der ikke fungere anyway.
  /*buttonStateStart = digitalRead(buttonpinStart);
  if (buttonStateStart == HIGH) {
    //Spilleren har trykket start
    //Serial.println("T");
    //Serial.write(2);
    //Serial.flush();
    //delay(5);
  }*/
  
  digitalWrite(LED, HIGH);            // Tænder Led'en, den står altid tændt
  ldrStatus = analogRead(ldrPin);     // Vi sætter lige sensor pinen, til en værdi vi kan læse
  sensor();                           // Tjekker om sensoren har en værdi over eller under 400
  
 if (Serial.available()){             // Hvis der bliver skrevet noget i konsollen. 
  int motor = Serial.parseInt();      // Værdien der bliver skrevet i konsollen, skriver vi ind i motor værdien.
  
  if(motor == 3){                     // Hvis der står tallet 3 i variablen motoren
    for (int i = 0; i <= 400; i++) {  // For hvert i, som der er 400 af, kører vi metoden onestep
      onestep();
    }
    motor = 0;                        // Sætter motor varablen til 0, så vi ikke bliver ved med at kører igennem samme loop
  }
  if(motor == 4){                     // Hvis der står tallet 4 i variablen motoren
    for (int i = 0; i <= 400; i++) {  // For hvert i, som der er 400 af, kører vi metoden revonestep
      revonestep();
    }
    motor = 0;                        // Sætter motor varablen til 0, så vi ikke bliver ved med at kører igennem samme loop
  }   
 }
}
