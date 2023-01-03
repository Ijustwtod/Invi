using Invi.Models;
using System.Collections.Generic;
using System.Linq;

namespace Invi.Abilities
{
    public static class LoadModelFromConfig
    {
        //private static InviSmartHomeRoot.Root inviRoot;
        //private static YandexSmartHomeRoot.Root yandexRoot;

        //public static InviSmartHomeRoot BuildRoot(InviSmartHomeRoot.Root ir)
        //{
        //    if (ir == null)
        //        inviRoot = new InviSmartHomeRoot.Root();
        //    else inviRoot = ir;

        //    yandexRoot = new YandexSmartHomeRoot().r;
        //    yandexRoot.devices = yandexRoot.devices.ToList();
        //    FillRoot();
        //    return null;
        //}
        //private static void FillRoot()
        //{
        //    inviRoot.status = yandexRoot.status;

        //    FillRooms();
        //    FillScenarios();



        //}
       
        //private static void FillRooms()
        //{
        //    foreach (var item in yandexRoot.rooms)
        //    {
        //        inviRoot.rooms.Add(new InviSmartHomeRoot.Room() { name = item.name, household_id = item.household_id, richdevices = new List<InviSmartHomeRoot.Device>() });
        //    }
        //}
        //private static List<InviSmartHomeRoot.Device> FillRoomDevice(string roomName)
        //{
        //    var deviceList = new List<InviSmartHomeRoot.Device>();
        //    foreach (var item in yandexRoot.devices.Where(d => d.room == roomName))
        //    {
        //        deviceList.Add(new InviSmartHomeRoot.Device() { name = item.name, type = item.type, room = item.room, aliases = item.aliases, capabilities = new List<InviSmartHomeRoot.Capability>() });
        //    }
        //    return null;
        //}
        //private static InviSmartHomeRoot.Capability NormalizeCapability(InviSmartHomeRoot.Device capability)
        //{
        //    var inviCapability = new List<InviSmartHomeRoot.Capability>();
        //    inviCapability.Add(new InviSmartHomeRoot.Capability());
        //    inviCapability.Add(new InviSmartHomeRoot.Capability());
        //    inviCapability.Add(new InviSmartHomeRoot.Capability());

        //    foreach (var item in capability.capabilities)
        //    {
        //        if (item.type == "devices.capabilities.on_off")
        //        {
        //            inviCapability[0] =
        //        }
        //        if (item.type == "devices.capabilities.range")
        //        {

        //        }
        //        if (item.type == "devices.capabilities.color_setting")
        //        {

        //        }
        //    }

        //    return null;
        //}
        //private static InviSmartHomeRoot.Capability FillNewCapability(YandexSmartHomeRoot.Capability capability)
        //{
        //    return new InviSmartHomeRoot.Capability() { type = capability.type, last_updated = capability.last_updated, parameters = new InviSmartHomeRoot.Parameters() { color_model = capability.parameters }, reportable = capability.reportable };

        //    inviCapability.parameters = new InviSmartHomeRoot.Parameters();
        //}
        //private static InviSmartHomeRoot.Parameters FillNewParameters(YandexSmartHomeRoot.Parameters yParam)
        //{
        //    return new InviSmartHomeRoot.Parameters() { type = capability.type, last_updated = capability.last_updated, parameters = new InviSmartHomeRoot.Parameters() { color_model = capability.parameters }, reportable = capability.reportable };

        //    inviCapability.parameters = new InviSmartHomeRoot.Parameters();
        //}
        //private static void FillScenarios()
        //{
        //    foreach (var item in yandexRoot.scenarios)
        //    {
        //        inviRoot.scenarios.Add(new InviSmartHomeRoot.Scenario() { id = item.id, name = item.name, is_active = item.is_active });
        //    }
        //}
    }
}
