import { LylBoilerPlateTemplatePage } from './app.po';

describe('LylBoilerPlate App', function() {
  let page: LylBoilerPlateTemplatePage;

  beforeEach(() => {
    page = new LylBoilerPlateTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
