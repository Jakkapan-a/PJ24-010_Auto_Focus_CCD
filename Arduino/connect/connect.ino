/**
 * @file connect.ino
 * @author Jakkapan
 * @brief
 * @version 0.1
 * @date 2024-05-15
 *
 * @copyright Copyright (c) 2024
 * Board: Leonardo
 */
#define BUFFER_SIZE_DATA 256
// -------------------- SERIAL 1 -------------------- //
bool startReceived1 = false;
bool endReceived1 = false;
const char startChar1 = '$';
const char endChar1 = '#';
char inputString1[BUFFER_SIZE_DATA];
int inputStringLength1 = 0;
void serialEvent()
{
    while (Serial.available())
    {
        byte inChar = (byte)Serial.read();
        if (inChar == startChar1)
        {
            startReceived1 = true;
            inputStringLength1 = 0;
            memset(inputString1, 0, BUFFER_SIZE_DATA);
        }
        else if (startReceived1 && inChar == endChar1)
        {
            endReceived1 = true;
        }
        else if (startReceived1)
        {
            if (inputStringLength1 < BUFFER_SIZE_DATA - 1)
            {
                inputString1[inputStringLength1++] = inChar;
            }
            else
            {
                startReceived1 = false;
                endReceived1 = false;
                inputStringLength1 = 0;
            }
        }
    }
}

void setup()
{
    Serial1.begin(9600);
    Serial.begin(9600);
    Serial.println("Hello World");
    Serial1.println("Hello World");

    // Clear buffer
    memset(inputString1, 0, BUFFER_SIZE_DATA);
}

void loop()
{
  manageSerial1();
}

void manageSerial1()
{
    if (startReceived1 && endReceived1)
    {
        startReceived1 = false;
        endReceived1 = false;
        inputString1[inputStringLength1] = '\0';
        Serial.println(inputString1);
        parseData(inputString1);
        memset(inputString1, 0, BUFFER_SIZE_DATA);
        inputStringLength1 = 0;
    }
}

void parseData(String data)
{
    data.trim();
    if (data.indexOf("CONN:") != -1)
    {
        // Send data to MES
        // String extract = extractData(data, "STATUS_SERVER:");

        Serial.println("$RECEIVED:OK#");
    }
}