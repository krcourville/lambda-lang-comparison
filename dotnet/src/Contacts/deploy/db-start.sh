#!/usr/bin/env bash

docker run -d -p 0.0.0.0:8000:8000 cnadiminti/dynamodb-local:latest -inMemory
