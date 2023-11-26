    FROM mcr.microsoft.com/dotnet/runtime-deps:6.0-alpine-amd64

    EXPOSE 8080

    RUN mkdir /app
    WORKDIR /app
    COPY ./linux64_musl/. ./

    RUN chmod +x ./Hotel_Api
    CMD ["./Hotel_Api", "--urls", "http://0.0.0.0:8080"]