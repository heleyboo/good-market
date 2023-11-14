DOTNET_RUN = dotnet
DOCKER_COMPOSE = docker compose

up:
	${DOCKER_COMPOSE} up -d

down:
	${DOCKER_COMPOSE} down

migration:
	$(DOTNET_RUN) ef migrations add ${name} --context=GmDbContext

dbupdate:
	$(DOTNET_RUN) ef database update --context=GmDbContext

run:
	$(DOTNET_RUN) run

watch:
	$(DOTNET_RUN) watch

add:
	$(DOTNET_RUN) add package ${name}