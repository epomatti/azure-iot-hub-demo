# Azure IoT Hub

A sample to demonstrate Azure IoT capabilities.

## Required software

* Azure CLI
* Azure CLI IoT Extension (`az extension add --name azure-cli-iot-ext`)

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

Device to Cloud (D2C):

```
az iot hub monitor-events -n happybeerhub
az iot device send-d2c-message -n happybeerhub -d test-device-02 --data 'Hello from Azure CLI'
```

Cloud to Device (C2D):

```
az iot device c2d-message send -n happybeerhub -d test-device-02 --data 'Hello, device, from Azure CLI'
az iot device c2d-message receive -n happybeerhub -d test-device-02
```

Simulate Device:

```
az iot hub monitor-events -n happybeerhub
az iot device simulate -n happybeerhub -d test-device-01 --data "Message from simulated device!" --msg-count 5
```