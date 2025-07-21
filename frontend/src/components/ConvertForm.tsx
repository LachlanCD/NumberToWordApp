import { type FormEvent } from "react";

interface ConvertFormProps {
  amount: string;
  setAmount: (value: string) => void;
  onSubmit: (e: FormEvent<HTMLFormElement>) => void;
}

const ConvertForm = ({ amount, setAmount, onSubmit }: ConvertFormProps) => {
  return (
    <form onSubmit={onSubmit} className="space-y-4">
      <input
        id="amount"
        type="text"
        placeholder="Enter amount"
        value={amount}
        onChange={(e) => setAmount(e.target.value)}
        className="w-full px-4 py-2 rounded bg-stone-700 text-stone-100 border border-stone-600 placeholder-stone-400 focus:outline-none focus:ring-2 focus:ring-stone-500"
      />

      <button
        type="submit"
        className="w-full py-2 bg-stone-700 rounded text-lg font-medium hover:bg-stone-600 transition"
      >
        Convert
      </button>
    </form>
  );
};

export default ConvertForm;
