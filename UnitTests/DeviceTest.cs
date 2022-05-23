using Autofac.Extras.Moq;
using Moq;
using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;
using System.Collections.Generic;
using Xunit;
using LOGIC.DeviceLogic;

namespace UnitTests
{
    public class DeviceTest
    {
        private List<DeviceDTO> GetSampleDevices()
        {
            List<DeviceDTO> devices = new List<DeviceDTO>
            {
                new DeviceDTO
                {
                    DeviceId = 1023,
                    ClientId = null,
                    TicketId = null,
                    DeviceName = "iPhone 12",
                    DeviceVersion = "12",
                    Brand = "Apple",
                    OsVersion = "13",
                    SerialNumber = "123456",
                },

                new DeviceDTO
                {
                    DeviceId = 1024,
                    ClientId = null,
                    TicketId = null,
                    DeviceName = "Samsung Galaxy S8",
                    DeviceVersion = "S8",
                    Brand = "Samsung",
                    OsVersion = "9",
                    SerialNumber = "123456",
                }
            };
            return devices;
        }

        private DeviceDTO GetSampleDevice()
        {
            DeviceDTO device = new DeviceDTO
            {
                DeviceId = 1025,
                ClientId = null,
                TicketId = null,
                DeviceName = "Samsung Galaxy S9",
                DeviceVersion = "S9",
                Brand = "Samsung",
                OsVersion = "9",
                SerialNumber = "123456",
            };

            return device;
        }

        [Fact]
        public void TestGetDevices()
        {
            // Arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IDeviceDal>().Setup(x => x.GetDevices()).Returns(GetSampleDevices);

            var logicMock = mock.Create<DeviceLogic>();

            var expectedResult = GetSampleDevices();

            var actualResult = logicMock.GetDevices();

            // Assert   
            Assert.True(actualResult != null);

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(expectedResult[i].DeviceId, actualResult[i].DeviceId);
            }
        }

        [Fact]
        public void TestAddDevice()
        {
            // Arrange
            using var mock = AutoMock.GetLoose();
            var device = new DeviceDTO
            {
                DeviceId = 1025,
                ClientId = null,
                TicketId = null,
                DeviceName = "Samsung Tab",
                DeviceVersion = "1",
                Brand = "Samsung",
                OsVersion = "13",
                SerialNumber = "123456",
            };

            mock.Mock<IDeviceDal>().Setup(x => x.AddDevice(device));
            var logicMock = mock.Create<IDeviceDal>();

            // Act
            logicMock.AddDevice(device);

            // Assert
            mock.Mock<IDeviceDal>().Verify(x => x.AddDevice(device), Times.Once);
        }

        [Fact]
        public void TestUpdateDevice()
        {
            // Arrange
            using var mock = AutoMock.GetLoose();
            var device = new DeviceDTO
            {
                DeviceId = 1025,
                ClientId = null,
                TicketId = null,
                DeviceName = "Samsung Tab 2",
                DeviceVersion = "2",
                Brand = "Samsung",
                OsVersion = "14",
                SerialNumber = "123456",
            };

            mock.Mock<IDeviceDal>().Setup(x => x.UpdateDevice(device));
            var logicMock = mock.Create<DeviceLogic>();

            // Act
            logicMock.UpdateDevice(device);

            // Assert
            mock.Mock<IDeviceDal>().Verify(x => x.UpdateDevice(device), Times.Once);
        }

        [Fact]
        public void TestDeleteDevice()
        {
            // Arrange
            using var mock = AutoMock.GetLoose();
            int deviceId = 1025;
            mock.Mock<IDeviceDal>().Setup(x => x.DeleteDevice(deviceId));
            var logicMock = mock.Create<DeviceLogic>();

            // Act
            logicMock.DeleteDevice(deviceId);

            // Assert
            mock.Mock<IDeviceDal>().Verify(x => x.DeleteDevice(deviceId), Times.Once);
        }

        [Fact]
        public void TestGetDevice()
        {
            // Arrange
            using var mock = AutoMock.GetLoose();
            var device = GetSampleDevice();
            mock.Mock<IDeviceDal>().Setup(x => x.GetDevice(device.DeviceId)).Returns(GetSampleDevice);

            var logicMock = mock.Create<DeviceLogic>();

            var expectedResult = GetSampleDevice();

            var actualResult = logicMock.GetDevice(device.DeviceId);

            // Assert
            Assert.True(actualResult != null);
            Assert.IsType<Device>(actualResult);
            Assert.Equal(expectedResult.DeviceId, actualResult.DeviceId);
        }
    }
}