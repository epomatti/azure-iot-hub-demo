
Azure CLI
 `az extension add --name azure-cli-iot-ext`

## Add Device

VS Code

1. Open command pallete <kbd>Ctrl</kbd>+<kbd>Shirt</kbd>+<kbd>P</kbd>
2. Access `Azure IoT Hub: Show Welcome Page`
3. Select IoT Hub
4. Select Subscription
5. Select the Hub
6. Expand `Azure IoT Hub Devices` sidebar
7. Choose `Create Device` on menu and add device

Azure CLI + IoT Extensions

* `az login`
* `az iot hub device-identity create --device-id teste-device-02 --hub-name happybeerhub`

## Sending Messages

Device to Cloud message:

1. `az iot device send-d2c-message -n happybeerhub -d test-device-02 --data 'Hello from Azure CLI'`
2. `az iot hub monitor-events -n happybeerhub`

Cloud to Device:

1. `az iot device c2d-message send -n happybeerhub -d test-device-02 --data 'Hello, device, from Azure CLI'`
2. `az iot device c2d-message receive -n happybeerhub -d test-device-02`