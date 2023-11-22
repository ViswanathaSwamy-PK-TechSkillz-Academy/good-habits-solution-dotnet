# https://hub.docker.com/_/microsoft-vscode-devcontainers?tab=description
# https://mcr.microsoft.com/v2/vscode/devcontainers/dotnet/tags/list
# [Choice] .NET version: 7.0, 6.0, 5.0, 3.1, 6.0-bullseye, 5.0-bullseye, 3.1-bullseye, 6.0-focal, 5.0-focal, 3.1-focal
ARG VARIANT="8.0-bookworm-slim"

FROM mcr.microsoft.com/vscode/devcontainers/dotnet:${VARIANT}

# [Choice] Node.js version: none, lts/*, 16, 14, 12, 10
ARG NODE_VERSION="none"

RUN if [ "${NODE_VERSION}" != "none" ]; then su vscode -c "umask 0002 && . /usr/local/share/nvm/nvm.sh && nvm install ${NODE_VERSION} 2>&1"; fi

# [Optional] Uncomment this section to install additional OS packages.
RUN apt-get update && \
    export DEBIAN_FRONTEND=noninteractive && \
    apt-get -qy full-upgrade && \
    apt-get install -qy curl && \
    apt-get -y install --no-install-recommends vim && \
    curl -sSL https://get.docker.com/ | sh

RUN dotnet tool install -g dotnet-ef

# Install .NET 7
# RUN curl -SL --output dotnet.tar.gz https://dotnetcli.azureedge.net/dotnet/Runtime/7.0.0/dotnet-runtime-7.0.0-linux-x64.tar.gz \
#     && echo "91c8321096a334870be1447a2ce1e4280f0c2f1e4051ac48bf365b13243a2e8d dotnet.tar.gz" | sha256sum -c - \
#     && mkdir -p /usr/share/dotnet \
#     && tar -zxf dotnet.tar.gz -C /usr/share/dotnet \
#     && rm dotnet.tar.gz \
#     && ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet7

# RUN wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh \
#     && chmod +x dotnet-install.sh \
#     && ./dotnet-install.sh -c 7.0 \
#     && rm dotnet-install.sh

ENV PATH $PATH:/root/.dotnet/tools

# configure for https
RUN dotnet dev-certs https
