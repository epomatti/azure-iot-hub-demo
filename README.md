# Azure IoT Hub

A sample to demonstrate Azure IoT capabilities.

## Tools

* Azure CLI
* Azure CLI IoT Extension (`az extension add --name azure-cli-iot-ext`)

## Create Services

1. IoT Hub using `scripts/iot-hub.ps` script.
2. Device Provisioning Service: `az iot dps create -n happybeerdps -g happybeer -l eastus`
2. Add Linked IoT Hubs using the portal.
3. Device: `az iot hub device-identity create --device-id test-device-01 --hub-name happybeerhub`

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

## Enrollment

You'll need the device Connection String:

```
az iot hub device-identity show-connection-string `
--hub-name happybeerhub-us
--device-id test-device-01
--output table`
```

Clone and run this to create certificates:

https://github.com/MattHoneycutt/ps-create-iot-solutions/tree/master/device-provisioning-sample

After generating the private key and the certificate, add an individual enrollment using the Portal.

## Connect the Device

1. Go to the DPS and copy the **ID Scope** value.
2. Run the app again with the ID Scope value: `dotnet run <id_scope>`

## Security

https://docs.microsoft.com/en-us/azure/iot-dps/concepts-security#hardware-security-module

## References

https://docs.microsoft.com/en-us/azure/iot-dps/quick-enroll-device-x509-csharp

https://docs.microsoft.com/en-us/azure/iot-hub/quickstart-send-telemetry-dotnet
