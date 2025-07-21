import { type ConvertRequest, type ConvertResponse } from "../types/types";

export async function convertAmount(
  request: ConvertRequest
): Promise<ConvertResponse> {
  const response = await fetch("/api/convert", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(request),
  });

  if (!response.ok) {
    throw new Error(`API Error: ${response.status}`);
  }

  const data: ConvertResponse = await response.json();
  return data;
}

