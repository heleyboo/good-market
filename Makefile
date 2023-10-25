DOTNET_RUN = dotnet
DOCKER_COMPOSE = docker compose
up:
	${DOCKER_COMPOSE} up -d

down:
	${DOCKER_COMPOSE} down

migration:
	$(DOTNET_RUN) ef migrations add ${name}

dbupdate:
	$(DOTNET_RUN) ef database update

run:
	$(DOTNET_RUN) run

watch:
	$(DOTNET_RUN) watch