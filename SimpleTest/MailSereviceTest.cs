using Notification.Objects;
using Moq;
using Xunit;
using Castle.Core.Smtp;

namespace SimpleTest
{
    public class MailServiceTest
    {
        [Fact]
        public void SendNotificationTest()
        {
            //Arrange
            var emailSenderMock = new Mock<IMailService>();
            emailSenderMock.Setup(sender => sender.SendEmailNotificationAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            var emailService = new SmtpEmailService();

            //Act
            // Вызовите метод отправки email с тестовыми данными
            var result =  emailService.SendEmailNotificationAsync("dunaevskyilya@gmail.com", "Fangarh.666@yandex.com", "Заголовок", "Hello World");

            // Assert
            // Добавьте утверждение (assertion) для проверки успешной отправки email. Например:
            //Assert.True();
            emailSenderMock.Verify(sender => sender.SendEmailNotificationAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);

        }
    }
}
