module.exports = {
    "/api": {
      target: (() => {
        // console.log("=== Variables d'environnement Aspire ===");
        // Object.keys(process.env)
        //   .filter(key => key.startsWith('services__'))
        //   .forEach(key => console.log(`${key} = ${process.env[key]}`));
        
        const target = process.env["services__easycomptaapi__https__0"] ||
                      process.env["services__easycomptaapi__http__0"];
        // console.log("Target URL:", target);
        return target;
      })(),
      secure: process.env["NODE_ENV"] !== "development",
      pathRewrite: {
        "^/api": "",
      },
    },
  };