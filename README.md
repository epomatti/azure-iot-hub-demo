# Azure IoT Hub Demo

Azure IoT features demo.

## Tools

You'll need to following software to run this demo:

* Visual Studio 2019
* Azure CLI
* Azure CLI IoT Extension (`az extension add --name azure-cli-iot-ext`)

## Provisioning the Infrastructure

1. First create the IoT Hub:

```powershell
# Login and setup your default location
az login -u <username>
az configure --defaults location=eastus

# Group creation
$group="iotdemo"
az group create -n $group

# Create IoT Hub with free SKU (cannot to be upgraded to Basic or Standard)
az iot hub create -n "iotdemohub999" -g $group --sku F1
```

2. Device Provisioning Service:

```powershell
az iot dps create -n happybeerdps -g $group
```

3. Add Linked IoT Hubs using the portal.
4. Device: `az iot hub device-identity create --device-id test-device-01 --hub-name happybeerhub`

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
