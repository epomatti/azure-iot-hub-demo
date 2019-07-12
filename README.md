# Azure IoT Hub

A sample to demonstrate Azure IoT capabilities.

## Tools

* Azure CLI
* Azure CLI IoT Extension (`az extension add --name azure-cli-iot-ext`)

## Create Services

Create the IoT Hub using `scripts/iot-hub.ps` script.

Create the Device Provisioning Service (DPS) using the portal.

Create the device: `az iot hub device-identity create --device-id teste-device-01 --hub-name happybeerhub`

## Sending Messages

Device to Cloud (D2C):

```
az iot hub monitor-events -n happybeerhub
az iot device send-d2c-message -n happybeerhub -d test-device-01 --data 'Hello from Azure CLI'
```

Cloud to Device (C2D):

```
az iot device c2d-message send -n happybeerhub -d test-device-01 --data 'Hello, device, from Azure CLI'
az iot device c2d-message receive -n happybeerhub -d test-device-01
```

Simulate Device:

```
az iot hub monitor-events -n happybeerhub
az iot device simulate -n happybeerhub -d test-device-01 `
--data "Message from simulated device!" `
--msg-count 5
```

## Security

https://docs.microsoft.com/en-us/azure/iot-dps/concepts-security#hardware-security-module
