import { WordGamecorePage } from './app.po';

describe('WordGamecore App', () => {
  let page: WordGamecorePage;

  beforeEach(() => {
    page = new WordGamecorePage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
