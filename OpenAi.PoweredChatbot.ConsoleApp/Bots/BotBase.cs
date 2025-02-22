﻿using System.ClientModel;
using OpenAI.Chat;

namespace OpenAi.PoweredChatbot.ConsoleApp.Bots;

internal abstract class BotBase(ChatClient client)
{
    protected ChatClient Client { get; } = client;

    protected List<ChatMessage> Messages { get; } = [];

    public abstract string Name { get; }

    public virtual ChatCompletionOptions Options { get; } = new ChatCompletionOptions { Temperature = 0.7f };

    public abstract void InitBot();

    public virtual string? CompleteChat(string? userMessage)
    {
        Messages.Add(new UserChatMessage(userMessage));
        ClientResult<ChatCompletion> result = Client.CompleteChat(Messages, Options);
        string? response = result.Value?.Content[0]?.Text;
        if (response is null)
            return null;

        // On enrichit le contexte de la conversation
        Messages.Add(new SystemChatMessage(response));
        return response;
    }
}