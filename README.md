# MsOwinDemo

重现 Jexus 独立版 6.2.x 运行 Microsoft.Owin + WebApi 时的 bug 。

- 直接运行项目， 使用 nowin 作为服务器来运行， 访问 <http://localhost:5000/index.html> ， `Form Post` 和 `Ajax Post` 两个按钮的功能正常；
- 将编译出的文件使用 Jexus 独立版 6.2.x 运行， `Form Post` 和 `Ajax Post` 两个按钮的功能均出错；
